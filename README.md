# Тестовое задание Level26

Список ассетов:
* [3D Defence Lazer Turret](https://assetstore.unity.com/packages/3d/environments/sci-fi/3d-defence-lazer-turret-190350)
* [Attack Helicopter](https://assetstore.unity.com/packages/3d/vehicles/air/attack-helicopter-ii-animations-8405)
* [Plane fighter](https://assetstore.unity.com/packages/3d/vehicles/air/lagg-3-black-death-ww2-fighter-140089)
* [Sounds](https://mixkit.co/free-sound-effects/gun/) and [here](https://pixabay.com/sound-effects/search/helicopter/)
* ~~[Explosions](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/hq-explosions-pack-free-263326)~~
* [Explosions](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/particle-dissolve-shader-package-33631)
* [Sand textures](https://assetstore.unity.com/packages/2d/textures-materials/nature/yughues-free-sand-materials-12964)


Структура:
- Assets
    - Game: основная папка с игрой
        - **Animations**: анимации для противников и UI
        - **Audio**: звуки взрывов, стрельбы и полета противников
        - **Prefabs**: префабы игровых объектов (игрок, противники, UI, снаряды и игровой менеджер)
        - **Scenes**: сцены игры
        - **Scripts**
          - *CrashBehaviour*: поведение объекта, при падении на землю
          - *Damage*: базовый класс для нанесения урона
          - *DebugArrow*: стрелка для отладки
          - *Enemy*: базовый класс для противников
          - *GameManager*: игровой менеджер
          - *Health*: класс для работы со здоровьем объектов
          - *HealthBar*: UI для отображения здоровья объекта
          - *ImpactDamage*: класс для урона, наносимого при столкновении объектов
          - *Input*: управление вводом игрока
          - *TurretRotator*: класс для вращения турели
          - *TurretShooter*: класс для стрельбы из турели
        - **Sprites**
        - **Terrain**
  

[Demo](https://youtube.com/shorts/iZhPDFm83yk)