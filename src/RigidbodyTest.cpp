#include "RigidbodyTest.h"

float globalTicks;
int width;
int height;
PhysicsBody m_bouncer1;
PhysicsBody m_bouncer2;
PhysicsBody m_bouncer3;
PhysicsBody m_bouncer4;

float RandBetween(float low, float high);
void CheckCollision(PhysicsBody &a);
void BoxCollision(PhysicsBody &a, PhysicsBody &b);

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
    width = m_width;
    height = m_height;
    SDL_Surface* im = SDL_LoadBMP("res/Square.bmp");
    SDL_Texture* t = SDL_CreateTextureFromSurface(gRenderer, im);
    Dynamic m_1 = Dynamic(t, Rectangle(m_width/2 - 32, m_height/2 - 32, 64, 64), SDL_Color {139,172,15,255}, 10, Vector2(RandBetween(-100,100), RandBetween(-100,100)).Normalize() * 0.25);
    Dynamic m_2 = Dynamic(t, Rectangle(m_width/4 - 32, m_height/4 - 32, 64, 64), SDL_Color {139,172,15,255}, 10, Vector2(RandBetween(-100,100), RandBetween(-100,100)).Normalize() * 0.25);
    Dynamic m_3 = Dynamic(t, Rectangle(m_width/5 - 32, m_height/5 - 32, 64, 64), SDL_Color {139,172,15,255}, 10, Vector2(RandBetween(-100,100), RandBetween(-100,100)).Normalize() * 0.25);
    Dynamic m_4 = Dynamic(t, Rectangle(m_width/3 - 32, m_height/3 - 32, 64, 64), SDL_Color {139,172,15,255}, 10, Vector2(RandBetween(-100,100), RandBetween(-100,100)).Normalize() * 0.25);
    m_bouncer1 = PhysicsBody(m_1);
    m_bouncer2 = PhysicsBody(m_2);
    m_bouncer3 = PhysicsBody(m_3);
    m_bouncer4 = PhysicsBody(m_4);
    SDL_FreeSurface(im);
    globalTicks = SDL_GetTicks();
}

bool RigidbodyTest::Update()
{
    float dt = (SDL_GetTicks() - globalTicks);
    globalTicks = SDL_GetTicks();
    m_bouncer1.Update(dt);
    m_bouncer2.Update(dt);
    m_bouncer3.Update(dt);
    m_bouncer4.Update(dt);
    CheckCollision(m_bouncer1);
    CheckCollision(m_bouncer2);
    CheckCollision(m_bouncer3);
    CheckCollision(m_bouncer4);
    BoxCollision(m_bouncer1, m_bouncer2);
    BoxCollision(m_bouncer1, m_bouncer3);
    BoxCollision(m_bouncer1, m_bouncer4);
    BoxCollision(m_bouncer2, m_bouncer3);
    BoxCollision(m_bouncer2, m_bouncer4);
    BoxCollision(m_bouncer3, m_bouncer4);
    return Game::Update();
}

void RigidbodyTest::Draw()
{
    Game::Draw();
    m_bouncer1.Render(gRenderer);
    m_bouncer2.Render(gRenderer);
    m_bouncer3.Render(gRenderer);
    m_bouncer4.Render(gRenderer);
    SDL_SetRenderDrawColor(gRenderer,15,56,15,255);
    SDL_RenderPresent(gRenderer);
}

void RigidbodyTest::Close()
{
    Game::Close();
}

float RandBetween(float low, float high){
    return low + rand() / ((float)RAND_MAX/(high-low));
}

void CheckCollision(PhysicsBody &a){
    Vector2 pos = a.GetPos();
    if(pos.x <= 0 && a.GetVelocity().x <= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(1,0)));
        a.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.x >= width - a.GetScale().x && a.GetVelocity().x >=0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(-1,0)));
        a.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.y <= 0 && a.GetVelocity().y <= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(0,1)));
        a.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
    if(pos.y >= height - a.GetScale().y && a.GetVelocity().y >= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(0,-1)));
        a.m_renderColor = SDL_Color {(Uint8)(rand()%255), (Uint8)(rand()%255), (Uint8)(rand()%255), 255};
    }
}

void BoxCollision(PhysicsBody &a, PhysicsBody &b){
    if(a.GetRect().Intersects(b.GetRect())){
        Vector2 dir = (b.GetPos() - a.GetPos());
        dir = dir.Normalize();
        a.SetVelocity(dir * -0.25);
        b.SetVelocity(dir * 0.25);
    }
}
