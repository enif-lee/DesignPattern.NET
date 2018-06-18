![title](Images/title.png)

> 위임을 통해 기능 클래스와 구현 클래스 역할 분리하기

## Context

대부분의 객체 지향 프로그래밍에서 특정한 개념(클래스, 인터페이스 등)에 대한 계층(상속/구현)을
제공합니다. 이를 지원하는 목적으로는 확장/구현 두가지 개념으로 나뉩니다.

### 확장 계층

어떤 소프트웨어에서든지 기존 기능을 좀 더 확장하여 사용하기 위해 `BaseClass`를 상속받아
`ExtendClass`를 만듭니다. 또한 이것을 더 확장하며 `BetterExtendClass`를 만들기도합니다.
이를 **확장 계층** 혹은 **기능의 클래스 계층**이라 부릅니다.

- BaseClass
    - ExtendClass
        - BetterExtendClass


### 구현 계층

Template Method 패턴이라던지 혹은 인터페이스를 구현하는 것을 통해서 원하는 기능 셋을
만들고 실제 상위 인터페이스/추상 클래스는 이런 것들을 사용하기위한 API 역할을 합니다.
또한 이것을 통해서 기존 코드의 변경이 없이 소프트웨어의 추가적인 확장/변경 가능성을 제공했습니다.
이를 통칭 **구현 계층** 혹은 **구현의 클래스 계층**이라 부릅니다.

- AbtractClass/Interface
    - ConcreteClass
    - ImplementClass

## Problem

## Solution

## Summery