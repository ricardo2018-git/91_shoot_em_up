@echo off

REM Cria estruturas de pastas base
mkdir "%~dp0Animations"
mkdir "%~dp0Animations/Enemies"
mkdir "%~dp0Animations/Enemies/Boss_Name"
mkdir "%~dp0Animations/Enemies/Enemy1_Name"
mkdir "%~dp0Animations/Enemies/Enemy2_Name"
mkdir "%~dp0Animations/Items"
mkdir "%~dp0Animations/Player"
mkdir "%~dp0Material"
mkdir "%~dp0Prefabs"
mkdir "%~dp0Prefabs/Effects"
mkdir "%~dp0Prefabs/Enemies"
mkdir "%~dp0Prefabs/Items"
mkdir "%~dp0Prefabs/Player"
mkdir "%~dp0Prefabs/Scenario"
mkdir "%~dp0Scenes"
mkdir "%~dp0Scriptables"
mkdir "%~dp0Scriptables/Enemies"
mkdir "%~dp0Scriptables/Items"
mkdir "%~dp0Scriptables/Player"
mkdir "%~dp0Scripts"
mkdir "%~dp0Scripts/Enemies"
mkdir "%~dp0Scripts/Items"
mkdir "%~dp0Scripts/Reuse"
mkdir "%~dp0Scripts/Scenario"
REM mkdir "%~dp0Settings"
REM mkdir "%~dp0Settings/Scenes"
mkdir "%~dp0Sounds"
mkdir "%~dp0Sprites"

REM Para script para saber que terminou de criar pastas
pause	