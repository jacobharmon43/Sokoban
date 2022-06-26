#include "Game.h"

Game::Game(){
    m_width = 0;
    m_height = 0;
}
Game::Game(int width, int height){
    m_width = width;
    m_height = height;
}
Game::~Game(){}

void Game::Init(const char* name)
{
    SDL_Init(SDL_INIT_VIDEO);
    gWindow = SDL_CreateWindow(name, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, m_width, m_height, 0);
    gRenderer = SDL_CreateRenderer(gWindow, -1, 0);
    input = SDL_GetKeyboardState(NULL);
}

bool Game::Update(double deltaTime)
{
    Draw();
    return false;
}

void Game::Draw()
{
    SDL_RenderClear(gRenderer);
}

void Game::Close()
{
    SDL_DestroyRenderer(gRenderer);
    SDL_DestroyWindow(gWindow);
    SDL_Quit();
}

int Game::GetHeight(){
    return m_height;
}

int Game::GetWidth(){
    return m_width;
}
