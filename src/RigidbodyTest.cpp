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
    m_floor = Object(Rectangle(0, m_height - 16, m_width, 16), SDL_Color {48,98,48,255}, 10);
    m_box = new Rigidbody(Rectangle(0, 0, 16, 16), SDL_Color {155,188,15,255}, 10, Vector2(1,0));
}

bool RigidbodyTest::Update()
{
    float dt = SDL_GetTicks() - globalTicks;
    globalTicks = SDL_GetTicks();
    if(m_box->CheckCollision(m_floor)){
        m_box -> Move(Vector2(0, m_floor.GetPos().y - m_box -> GetPos().y - m_box -> GetScale().y));
        m_box -> SetVelocity(m_box -> GetVelocity() * Vector2(1,0));
    }
    m_box -> Update(dt);
    return false;
}

void RigidbodyTest::Draw()
{
    Game::Draw();
    m_floor.Render(gRenderer);
    m_box -> Render(gRenderer);
    SDL_SetRenderDrawColor(gRenderer,15,56,15,255);
    SDL_RenderPresent(gRenderer);
}

void RigidbodyTest::Close()
{
    delete m_box;
    Game::Close();
}
