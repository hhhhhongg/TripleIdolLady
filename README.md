# 📖Chapter 3-2 Unity 게임개발 입문 프로젝트 
### 👨‍👧‍👧1조 천홍, 정선교, 박재열, 이규성, 김종욱

## 📌선택한 게임

![닷지](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/0b283a36-df08-4731-9c39-31a1df475617)
- **필수 구현 사항**
    - **게임 화면**: 게임을 플레이할 수 있는 화면을 만들어야 합니다. 화면 크기, 배경 등을 설정해야 합니다.
    - **캐릭터**: 주인공 캐릭터와 적 캐릭터를 만들고, 이들을 움직일 수 있도록 구현해야 합니다. 주인공 캐릭터는 플레이어의 조작에 따라 움직여야 하며, 적 캐릭터는 일정한 패턴에 따라 움직여야 합니다.
    - **총알과 공격**: 주인공 캐릭터가 총알을 발사할 수 있도록 구현하고, 적 캐릭터에게 공격을 가할 수 있어야 합니다. 또한, 적 캐릭터의 공격 동작을 정의해야 합니다.
    - **충돌 감지**: 총알과 적 캐릭터가 충돌했는지를 감지하고, 충돌 시 적 캐릭터를 제거하고 점수를 증가시켜야 합니다.
    - **게임 로직**: 게임의 기본 로직을 구현해야 합니다. 게임 시작, 종료, 점수, 생명 등을 관리해야 합니다.
- **선택 구현 사항**
    - **게임 난이도 조절**: 난이도를 조절하기 위해 적의 이동 속도, 총알의 발사 속도, 적의 패턴 등을 조절할 수 있습니다.
    - **아이템 시스템**: 게임을 더 흥미롭게 만들기 위해 아이템 시스템을 도입할 수 있습니다. 플레이어가 아이템을 획득하면 임시로 강화되는 아이템, 체력을 회복하는 아이템 등을 추가할 수 있습니다.
    - **특수 능력**: 플레이어 캐릭터에 특수 능력을 부여하여 게임 플레이를 다양화할 수 있습니다. 예를 들어, 무적 모드, 빠른 이동 모드 등을 추가할 수 있습니다.
    - **멀티플레이어 모드**: 다른 플레이어와 함께 플레이할 수 있는 로컬 멀티플레이어 모드를 추가할 수 있습니다.
    - **시각적 효과**: 게임에 다양한 시각적 효과를 추가하여 게임의 시각적 품질을 향상시킬 수 있습니다.
    - **사운드 효과**: 게임에 배경 음악과 효과음을 추가하여 게임의 분위기를 높일 수 있습니다.

일반적인 닷지는 사방에서 날아오는 탄알을 피하면서 버틸 뿐인 게임이지만 구현 사항을 읽어보니 그냥 닷지가 아닌 탄막 게임을 구현해야 한다.

### ✅구현에 성공한 사항들
게임 화면  
캐릭터  
총알과 공격  
충돌 감지  
게임 로직  
게임 난이도 조절  
아이템 시스템  
사운드 효과

-----

### 💾사용된 프로그램
Unity Engine 2022.3.2f LTS  
Visual Studio 2022(C#)

### 💾깃허브 사용 방식
Clone 방식으로 진행하였습니다.  
Check Branch에 각자 작업물들을 merge하면서 진행하였습니다.  
최종 작업물을 main에 merge하였습니다.

-----

### ✅게임의 컨셉
1. 배경은 우리가 공부하는 ZEP
2. TopDownView
3. 플레이어는 팀원의 ZEP캐릭터
4. 에너미는 ZEP캐릭터를 이용하여 만든 좀비
5. 스코어는 따로 없으며 시간이 지날 수록 강한 에너미 등장
6. 보스가 존재하며 처치 시 승리 !
## 📌게임의 정보
### ⌨🖱조작법
WASD: 플레이어의 이동  
Mouse point: 플레이어가 바라보는 방향  
Mouse LBT: 공격

-----

### 🤺플레이어 캐릭터
플레이어 1의 이미지와 무기
![Player1](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/469529f0-3cac-433e-b8ac-3f6cade99c72)
![Player1Weapon](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/643449f2-07b1-4fac-b791-dcb4f6ad306e)

플레이어 2의 이미지와 무기
![Player2](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/beaf8263-1300-46bc-bd2b-c301b11dd22f)
![Player2Weapon](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/348e86ca-6805-44cf-b884-d3b6bca1ae1a)
![Player2Bullet](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/8dbc5316-568a-41eb-8f6f-8622a2b96244)

플레이어 3의 이미지와 무기
![Player3](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/d3811fc4-1100-4cf9-bb6c-a14dcce437c9)
![Player3Weapon](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/bf8c94d6-60c1-4d37-89ea-488ee620e3f6)

플레이어 4의 이미지와 무기
![Player4](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/656e9fb3-fc5e-4278-b8f2-9f661e9ddb3d)
![Player4Weapon](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/de2675b1-f3a3-4366-86e9-78fa72d553f1)

플레이어 5의 이미지와 무기
![Player5](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/0792844b-9d91-477b-abd6-15c60a94decf)
![1대지 1](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/5850d9bb-f6cc-4d9a-b9a7-fd6ff6aa9226)

플레이어의 각 무기는 팀원분들의 아이덴티티를 녹여내었다.

-----

### 🗃아이템
체력 회복 아이템
![Heart](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/a24cdd84-ac5c-4f22-b0fb-2db14fa1bcd0)

-----

### 💥에너미

에너미 1의 이미지
![Enemy1](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/b836e855-f055-4b77-ae9c-5b8ada8465ff)

에너미 2의 이미지
![Enemy2](https://github.com/hhhhhongg/TripleIdolLady/assets/149459020/5b5084b6-4d1b-4b06-8d57-fa8f5230f983)

보스는 발표 후 공개..!
