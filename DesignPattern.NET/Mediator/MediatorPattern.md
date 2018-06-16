![title](Images/mediator.png)

> 여러 객체간의 협업관계를 중앙화하는 패턴

## Context

GUI 개발을 하다보면 여러 컴포넌트간의 호출관계를 그릴 수 있습니다. 우리가 많이
개발하는 UI 중 하나인 로그인 폼을 예로 들어보겠습니다. 사용자의 이름과 암호,
Guest로 로그인, 로그인 폼이 있다고 생각해봅시다. 그럼 대략 아래와 같은 모양이
나올 것 입니다.

![form](Images/form.png)

그리고 기획 문서에는 아래와 같은 요구사항이 있습니다.

- Guest로 로그인이 체크된 경우
    - Username과 Password는 비활성화
    - Login 버튼 활성화
- Guest로 로그인이 체크가 되지않은 경우
    - Username은 활성화
    - Password는 Username에 한 글자라도 텍스트가 입력된 경우 활성화
    - Username과 Password 모두 내용이 있는 경우에만 Login버튼 활성화

일반적으로 빠르게 프로토타이핑을 시작하는 개발자는 이러한 요구사항을 각 컴포넌트
별로 구현하게 될 것입니다.

## Problem

`UsernameInput`, `PasswordInput`, `LoginButton`, `GuestCheckbox`, `CancelButton`
그리고 `LoginFormDialog` 클래스 혹은 객체들이 상호 연관관계가 되어 서로를 알고 있어야합니다.

![complex-relation](Images/complex.png)

위 방향대로 구현한다면 각 컴포넌트는 경우에는 연관된 모든 컴포넌트에
대해서 필드로 주입받고 그것을 제어하는 형태가 되어야할 것 입니다. 로직은 여기저기
퍼지게되며 자칫 어떠한 룰이 변경되면 중복된 로직만큼 수정해야할 수 있습니다.

```csharp
class GuestCheckBox : CheckBox
{
    private readonly Button _login;
    private readonly TextInput _username;
    private readonly TextInput _passwsord;

    public GuestCheckBox(Button login, TextInput username, TextInput passwsord)
    {
        _login = login;
        _username = username;
        _passwsord = passwsord;
    }


    void OnChanged()
    {
        if (Checked)
        {
            _login.Disable(Checked);
            _username.Disable(Checked);
            _passwsord.Disable(!string.IsEmpty(_username.Value) && Checked);
        }
    }
}

class UsernameInput : TextInput
{
    // contructor and fields...

    void OnChanged()
    {
        if (!string.IsEmpty(Value))
        {
            _password.Disable(false);

            if (!string.IsEmpty(_password.Value))
            {
                _loginButton.Disable(false);
            }
        }
    }
}
```

위 코드는 모든 컴포넌트(위젯)에 대해서 표현하진 않았지만 대략적으로 어떠한 코드가
작성될지 예상하실 수 있습니다. 관리적으로도 코드에서 요구사항을 파악할 때에도
분산된 코드에 따른 이유 때문에 아마 후임자가 들어온다면 원 작성자를 원망할지도
모르겠습니다.

![added](Images/additional-request.png)

또한 위와같이 `Input`필드가 하나라도 더 추가된다면 4개 혹은 그 이상의 연관관계가
그려집니다. 굉장히 복잡한 어플리케이션이 될 가능성이 높습니다.

## Solution

사실 OOP는 로직이나 책임을 여기저기 분해(분산)시키고 이를 조합/협업 관계를 통해
복잡성을 낮춰 높은 재사용/유지보수성을 달성할 수 있는데에 장점이 있습니다.
하지만 하나에서 여러개로 분산시킨다고 해서 항상 복잡성이 비례하여 낮춰지는 것은 아닙니다.
재사용성은 해당되는 객체(클래스, 모듈)의 독립성과 비례합니다. 즉 연관관계가 많은
수록 복잡성은 높고 재사용성은 떨어집니다. 위 예제에서는 *각각의 컴포넌트들을 다른
곳에서 재사용할 수 없음을 예상하실 수 있습니다.*

연관관계가 높은 이유에 대해서 생각해봅시다. 이는 각 컴포넌트에서 **요구사항에
따른 관계 컴포넌트를 직접 제어함**에서 발생합니다. 조건에 따른 제어로직을 한
곳으로 모아 관리할 순 없을까요? 그리고 그 역할을 맡을 중재자 컴포넌트는 무엇일까요?

`LoginFormDialog`는 모든 컴포넌트에 접근이 가능하여 중재자 역할로 적합합니다.

```csharp
class LoginFormDialog : IDialog
{
    private CheckBox IsGuest { get; }
    private TextInput Username { get; }
    private TextInput Password { get; }
    private Button Login { get; }
    private Button Cancel { get; }

    public LoginFormDialog()
    {
        IsGuest = new GuestCheckBox
        {
            OnClick = () => UpdateChanges;
        };
        // 다른 컴포넌트 생성 로직
    }

    public void UpdateChanges()
    {
        Username.Disable = !IsGuest.Checked;
        Password.Disable = !IsGuest.Checked && !string.IsNullOrEmpty(Username.Value);
        Login.Disable = !string.IsNullOrEmpty(Username.Value) && !string.IsNullOrEmpty(Password.Value);
    }
}
```

많은 연관관계가 있던 전에 비해 깔끔해졌습니다. 하지만 각 컴포넌트에서 어떤 이벤트일
때에 `UpdateChanges`가 호출될 것인가에 대해서는 해당 컴포넌트에서 결정되어야 합니다.
따라서 각 컴포넌트는 `LoginFormDialog`에 대해서 알고 있어야합니다.

```csharp
class UsernameInput : TextInput, IComponent
{
    public LoginFormDialog Dialog { get; set; }

    public UsernameInput()
    {
        OnChange += () => Dialog?.UpdateChanges();
    }
}
```

더불어 `LoginInput`이나 `PasswordInput`은 서비스에서 정한 규칙에 따른 검증 로직을
가지고 있고 이는 `Dialog` 뿐만 아니라 `MainView`, `OAuthPopup`등에서도 쓰일 수
있으므로 중재자 그 자체를 인터페이스로 변환해 느슨(Loose Couple)하게 만들어 줍시다.

```csharp
interface IMediator
{
    void UpdateChanges();
}

class UsernameInput : TextInput, IComponent
{
    public IMediator Mediator { get; set; }

    public UsernameInput()
    {
        OnChange += () => Mediator?.UpdateChanges();
    }
}
```

위와 같은 과정을 거치면 최종적으로 아래와 같은 다이어그램이 만들어집니다.

![solution](Images/SolutionERD.png)

## Summery