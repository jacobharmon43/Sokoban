all:
	g++ -Iinclude -Iinclude/SDL2 -Iinclude/JHEngine -Llib -o main src/*.cpp src/JHEngine/*.cpp main.cpp -lmingw32 -lSDL2main -lSDL2
linux:
	g++ -Llib -Iinclude -Iinclude/SDL2 -Iinclude/JHEngine  main.cpp src/*.cpp src/JHEngine/*.cpp -w -o linMain -lSDL2 -lSDL2main