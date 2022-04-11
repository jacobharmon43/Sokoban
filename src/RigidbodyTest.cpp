#include "RigidbodyTest.h"

float globalTicks = SDL_GetTicks();
Dynamic m_bouncer;
Object m_box;

float RandBetween(float low, float high);

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
    m_box = Object(t, Rectangle(m_width/2 - 64, m_height/2 - 64, 64, 64), SDL_Color {139,172,15,255}, 10);
    m_bouncer = Dynamic(m_box, Vector2(RandBetween(-1,1), RandBetween(-1,1)).Normalize());
    m_bouncer.SetVelocity(m_bouncer.GetVelocity() * 0.25f);
    SDL_FreeSurface(im);
}

bool RigidbodyTest::Update()
{
    float dt = (SDL_GetTicks() - globalTicks);
    globalTicks = SDL_GetTicks();
    m_bouncer.Update(dt);
    Vector2 pos = m_bouncer.GetPos();
    if(pos.x <= 0 && m_bouncer.GetVelocity().x < 0){
        m_bouncer.SetVelocity(m_bouncer.GetVelocity().Reflect(Vector2(1,0)));
        m_bouncer.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.x >= m_width - 64 && m_bouncer.GetVelocity().x > 0){
        m_bouncer.SetVelocity(m_bouncer.GetVelocity().Reflect(Vector2(-1,0)));
        m_bouncer.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.y <= 0 && m_bouncer.GetVelocity().y < 0){
        m_bouncer.SetVelocity(m_bouncer.GetVelocity().Reflect(Vector2(0,1)));
        m_bouncer.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.y >= m_height - 64 && m_bouncer.GetVelocity().y > 0){
        m_bouncer.SetVelocity(m_bouncer.GetVelocity().Reflect(Vector2(0,-1)));
        m_bouncer.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
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

float RandBetween(float low, float high){
    return low + (float)rand() / ((float)RAND_MAX/(high-low));
}
