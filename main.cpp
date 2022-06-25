#include <SDL.h>
#include <iostream>

#include <iostream>
#include "ParkSim.h"

bool PollQuit(SDL_Event event);

int main(int argc, char *argv[])
{
  ParkSimulator game = ParkSimulator(900,600);
  game.Init("Theme park Simulator");
  SDL_Event event;
  bool quitFlag = false;
  double lastPing = 0;
  double currentPing = 0;
  while(!quitFlag){
    lastPing = currentPing;
    currentPing = SDL_GetPerformanceCounter();
    double deltaTime = (currentPing - lastPing) * 1000 / (double)SDL_GetPerformanceFrequency();
    quitFlag = PollQuit(event);
    if(quitFlag) break;
    Uint64 start = SDL_GetPerformanceCounter();
    quitFlag = game.Update(deltaTime);
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