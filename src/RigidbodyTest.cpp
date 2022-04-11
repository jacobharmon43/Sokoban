#include "RigidbodyTest.h"

float globalTicks = SDL_GetTicks();
Dynamic m_bouncer;

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
    SDL_Surface* im = SDL_LoadBMP("res/Square.bmp");
    SDL_Texture* t = SDL_CreateTextureFromSurface(gRenderer, im);
    m_bouncer = Dynamic(t, Rectangle(m_width/2 - 8, m_height/2 - 8, 16, 16), SDL_Color {139,172,15,255}, 10, Vector2(0.5f,0.5f));
    SDL_FreeSurface(im);
}

bool RigidbodyTest::Update()
{
    float dt = (SDL_GetTicks() - globalTicks);
    globalTicks = SDL_GetTicks();
    float rot = fmod((m_bouncer.GetRotation() + dt),360);
    m_bouncer.SetRotation(rot);
    m_bouncer.Update(dt);
    Vector2 pos = m_bouncer.GetPos();
    if(pos.x < 0 || pos.x > m_width || pos.y < 0 || pos.y > m_height){
        m_bouncer.SetVelocity(m_bouncer.GetVelocity().Perpendicular());
    }
    return Game::Update();
}

void RigidbodyTest::Draw()
{
    Game::Draw();
    m_bouncer.Render(gRenderer);
    SDL_SetRenderDrawColor(gRenderer,15,56,15,255);
    SDL_RenderPresent(gRenderer);
}

void RigidbodyTest::Close()
{
    Game::Close();
}
