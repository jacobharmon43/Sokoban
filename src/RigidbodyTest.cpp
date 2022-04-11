#include "RigidbodyTest.h"

float globalTicks = SDL_GetTicks();

RigidbodyTest::RigidbodyTest()
{
    m_height = 0;
    m_width = 0;
}

RigidbodyTest::RigidbodyTest(int width, int height)
{
    m_height = height;
    m_width = width;
}

RigidbodyTest::~RigidbodyTest(){}

void RigidbodyTest::Init(const char* name)
{
    Game::Init(name);
    SDL_Texture* t = SDL_CreateTextureFromSurface(gRenderer, SDL_LoadBMP("res/Cat.bmp"));
    m_floor = Object(t, Rectangle(m_width/2 - 64, m_height/2 -64, 128, 128), SDL_Color {255,255,255,255}, 10);
}

bool RigidbodyTest::Update()
{
    float dt = SDL_GetTicks() - globalTicks;
    globalTicks = SDL_GetTicks();
    m_floor.SetRotation(m_floor.GetRotation() + 0.01f * dt);
    return false;
}

void RigidbodyTest::Draw()
{
    Game::Draw();
    m_floor.Render(gRenderer);
    SDL_SetRenderDrawColor(gRenderer,15,56,15,255);
    SDL_RenderPresent(gRenderer);
}

void RigidbodyTest::Close()
{
    Game::Close();
}
