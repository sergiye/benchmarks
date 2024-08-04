@echo off

rmdir /s /q .vs
rmdir /s /q .idea

rmdir /s /q .\Benchmarks\.vs
rmdir /s /q .\Benchmarks\obj
rmdir /s /q .\Benchmarks\bin
rem del /S ".\Benchmarks\bin\*.dll"
rem del /S ".\Benchmarks\bin\*.pdb"
rem del /S ".\Benchmarks\bin\*.xml"
