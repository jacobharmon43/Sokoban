#include "ParkSim.h"

float globalTicks;
int width;
int height;

list<Object*> allObjects;

ParkSimulator::ParkSimulator()
{
    m_height = 0;
    m_width = 0;
}

ParkSimulator::ParkSimulator(int width, int height)
{
    m_height = height;
    m_width = width;
}

ParkSimulator::~ParkSimulator(){
   for(auto it = allObjects.begin(); it != allObjects.end(); ++it){
       delete *it;
       *it = NULL;
    }
}

void ParkSimulator::Init(const char* name)
{
    Game::Init(name);
    width = m_width;
    height = m_height;
    SDL_Surface* im = IMG_Load("res/Cat.png");
    if(im == NULL) printf("Unable to load: %s", IMG_GetError());
    SDL_Texture* t = SDL_CreateTextureFromSurface(gRenderer, im);
    player = Object(t, Rectangle(0,0,128,128), SDL_Color {255,255,255,255}, 10);
    allObjects.push_back(&player);
    SDL_FreeSurface(im);
    globalTicks = SDL_GetTicks();
}

bool ParkSimulator::Update(double deltaTime)
{
    PollKeyboard(input);
    return Game::Update(deltaTime);
}

void ParkSimulator::Draw()
{
    Game::Draw();
    for(auto it = allObjects.begin(); it != allObjects.end(); ++it){
        (*it) -> Render(gRenderer);
    }
    SDL_SetRenderDrawColor(gRenderer,255,255,255,255);
    SDL_RenderPresent(gRenderer);
}

void ParkSimulator::Close()
{
    Game::Close();
}

bool ParkSimulator::PollKeyboard(const Uint8* input)
{
    int speed = 5;
    Vector2 movementVector = Vector2(0,-speed) * input[SDL_SCANCODE_W] + Vector2(-speed,0) * input[SDL_SCANCODE_A] + Vector2(0,speed) * input[SDL_SCANCODE_S] + Vector2(speed,0) * input[SDL_SCANCODE_D];
    player.MoveBy(movementVector);
    Vector2 newPos = player.GetPos();
}   
