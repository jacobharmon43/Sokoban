#include "Dynamic.h"

Dynamic::Dynamic(){}

Dynamic::Dynamic(Object obj, Vector2 velocity){
    m_renderColor = obj.m_renderColor;
    m_renderOrder = obj.m_renderOrder;
    m_texture = obj.m_texture;
    m_renderPosition = obj.GetRect();
    m_rotation = obj.GetRotation();
    m_velocity = velocity;
}

Dynamic::Dynamic(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, Vector2 velocity, float rotation){
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
    Object::SetPos(Object::GetPos() + m_velocity * deltaTime);
}

bool Dynamic::CheckCollision(Object collidable)
{
    return m_renderPosition.Intersects(collidable.GetRect());
}