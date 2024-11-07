# Escape From Factory
 
## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [팀소개](#팀소개)
3. [주요기능](#주요기능)
4. [개발기간](#개발기간)
5. [와이어프레임](#와이어프레임)
6. [UML DIAGRAM](#uml-diagram)
7. [Trouble Shooting](#trouble-shooting)
8. [프로젝트를 마치며](#프로젝트를-마치며)
    
## 프로젝트 소개
이번 프로젝트에서는 생존 게임을 선택했으며 플레이어가 상호작용을 통해 아이템을 수집할 수 있고, 건축물을 만들고, 무기를 착용하면 적을 공격할 수 있는 생존게임을 구성했습니다.

## 팀소개
저희 16조는 공장에서 좀비로봇을 피해 탈출하는 것이 목표인 게임을 목표로 개발을 시작했습니다.

## 주요기능

- 오브젝트 상호작용
모든 상호작용(E키)를 인터페이스를 통해 한 플레이어가 한 메소드로 접근합니다.

- 건축
B키를 눌러 건축 UI를 켜고 시계방향으로 생성, 이동, 파괴 입니다. B키와 마우스 좌클릭, R키(회전)으로 건축이 되고 건축물끼리 겹치지 않게 했습니다.

- 적 AI
Nav와 상태패턴을 활용하여 구성했습니다. 플레이어를 OverlapBox로 찾아서 접근합니다.

- 인벤토리
Tab키를 통해 접근할 수 있고, 상호작용[E]을 통해 인벤토리에 아이템을 획득할 수 있습니다.
획득한 아이템은 마우스 좌클릭으로 토글바에 올릴 수 있고, 토글바는 숫자버튼을 바탕으로 활성화 할 수 있습니다.

- 전투
빠루를 집어 인벤토리에서 좌클릭으로 토글바에 올리고, 버튼을 누르면 착용합니다. 좌클릭으로 공격이 가능합니다.

## 개발기간
- 2024.10.31(목) ~ 2024.11.07(목)

## 와이어프레임
[<img width="556" alt="Screenshot 2024-10-20 at 07 51 32" src="https://github.com/user-attachments/assets/ff0b0b7d-c782-4fd3-b884-d25aed019ea2">
<img width="772" alt="Screenshot 2024-10-20 at 07 51 49" src="https://github.com/user-attachments/assets/ad994364-8a0d-4183-9e15-c2d15432e18a">](https://www.figma.com/board/ttWzqbuGFE97y25eWtRpr7/16%EC%A1%B0%ED%94%BC%EA%B7%B8%EC%9E%BC?node-id=0-1&node-type=canvas&t=U3MYS6OR53p22wcM-0)

## UML DIAGRAM
![image](https://github.com/user-attachments/assets/5e4d47fe-2543-475e-9756-18d494966773)
발표 자료: https://www.canva.com/design/DAGT7VXHfjg/gYfX2kfhSfPO6Rd2ZKIqWA/view?utm_content=DAGT7VXHfjg&utm_campaign=designshare&utm_medium=link&utm_source=editor

## Trouble Shooting
https://www.notion.so/128df833f80680d7954bf9f5dc332bc4?p=136df833f80680e1a6f6d6e70eda0e50&pm=s
노션 맨 마지막 게시판에 적었습니다.

## 프로젝트를 마치며

팀장. 이태훈 : 

팀원. 김찬 : 

팀원. 손대오 : 

팀원. 홍신영 : 
