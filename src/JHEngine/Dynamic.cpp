#include "Dynamic.h"

Dynamic::Dynamic(){}

Dynamic::Dynamic(Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity, float rotation){
    m_renderPosition = renderPosition;
    m_renderColor = renderColor;
    m_renderOrder = renderOrder;
    m_velocity = velocity;
    m_rotation = rotation;
}

Dynamic::~Dynamic(){}

void Dynamic::SetVelocity(Vector2 set)
{
    m_velocity = set;
}

Vector2 Dynamic::GetVelocity()
{
    return m_velocity;
}

void Dynamic::Update(float deltaTime)
{
    //Object::Move(m_velocity);
}

bool Dynamic::CheckCollision(Object collidable)
{
    return m_renderPosition.Intersects(collidable.GetRect());
}

void Dynamic::Render(SDL_Renderer* r)
{
    Object::Render(r);
}

