#include "RigidbodyTest.h"

float globalTicks;
int width;
int height;
list<PhysicsBody> allObjects;

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
    Vector2 size = Vector2(5,5);
    Vector2 initPos = Vector2(48,48);
    SDL_Color c = SDL_Color {255,255,255,255};
    for(int i = 0; i < 500; ++i){
        allObjects.push_back(PhysicsBody(t,Rectangle(initPos + Vector2(size.x * (i % 50), size.y * (i/10) ) * 2, size), c, 10, Vector2(RandBetween(-1,1), RandBetween(-1,1)).Normalize()*0.25));
    }
    SDL_FreeSurface(im);
    globalTicks = SDL_GetTicks();
}

bool RigidbodyTest::Update()
{
    float dt = (SDL_GetTicks() - globalTicks);
    globalTicks = SDL_GetTicks();
    for(auto it = allObjects.begin(); it != allObjects.end(); ++it){
        double timer = SDL_GetTicks();
        it -> Update(dt);
        CheckCollision(*it);
        auto next = ++it;
        --it;
        for(auto it2 = next; it2 != allObjects.end(); ++it2){
            BoxCollision(*it, *it2);
        }
    }
    return Game::Update();
}

void RigidbodyTest::Draw()
{
    Game::Draw();
    for(auto it = allObjects.begin(); it != allObjects.end(); ++it){
        it -> Render(gRenderer);
    }
    SDL_SetRenderDrawColor(gRenderer,0,0,0,255);
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
    double maxX = width - a.GetScale().x;
    double maxY = height - a.GetScale().y;
    if(pos.x > 0 && pos.x < maxX && pos.y > 0 && pos.y < maxY) return;
    if(pos.x <= 0 && a.GetVelocity().x <= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(1,0)));
    }
    if(pos.x >= maxX && a.GetVelocity().x >=0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(-1,0)));
    }
    if(pos.y <= 0 && a.GetVelocity().y <= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(0,1)));
    }
    if(pos.y >= maxY && a.GetVelocity().y >= 0){
        a.SetVelocity(a.GetVelocity().Reflect(Vector2(0,-1)));
    }
}

void BoxCollision(PhysicsBody &a, PhysicsBody &b){
    if(a.GetRect().Intersects(b.GetRect())){
        Vector2 dir = ((b.GetPos() - b.GetScale()/2) - (a.GetPos() - a.GetScale()/2));
        dir = dir.Normalize();
        a.SetVelocity(dir * -0.25);
        b.SetVelocity(dir * 0.25);
    }
}
