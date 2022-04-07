#include <SDL.h>
#include <iostream>

#include <iostream>
#include "Pong.h"

bool PollQuit(SDL_Event event);

int main(int argc, char *argv[])
{
  Pong game = Pong(900,600);
  game.Init("Pong");
  SDL_Event event;
  bool quitFlag = false;
  while(!quitFlag){
    quitFlag = PollQuit(event);
    if(quitFlag) break;
    Uint64 start = SDL_GetPerformanceCounter();
    quitFlag = game.Update();
    game.Draw();
    SDL_Delay(10.0f - (SDL_GetPerformanceCounter() - start)/(float)SDL_GetPerformanceFrequency() * 1000.0f);
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