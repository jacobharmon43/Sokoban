#include <SDL.h>
#include <iostream>

#include <iostream>
#include "RigidbodyTest.h"

bool PollQuit(SDL_Event event);

int main(int argc, char *argv[])
{
  RigidbodyTest game = RigidbodyTest(900,600);
  game.Init("RigidbodyTest");
  SDL_Event event;
  bool quitFlag = false;
  while(!quitFlag){
    quitFlag = PollQuit(event);
    if(quitFlag) break;
    Uint64 start = SDL_GetPerformanceCounter();
    quitFlag = game.Update();
    SDL_Delay(2);
  }
  game.Close();
  return 0;
}

bool PollQuit(SDL_Event event){
  while(SDL_PollEvent(&event)){
    switch (event.type){
      case SDL_QUIT:
        return true;
    }
  }
  return false;
}