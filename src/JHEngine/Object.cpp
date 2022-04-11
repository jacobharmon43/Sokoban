#include "Object.h"

//* Constructors and Destructors *//

Object::Object(){}
Object::~Object() {}

Object::Object(SDL_Texture* t, Rectangle renderPosition, SDL_Color renderColor, int renderOrder, float rotation)
{
    m_renderPosition = renderPosition;
    m_renderColor = renderColor;
    m_renderOrder = renderOrder;
    m_rotation = rotation;
    m_texture = t;
}

//* Getters *//

Vector2 Object::GetPos()
{
    return Vector2(m_renderPosition.x, m_renderPosition.y);
}

Vector2Int Object::GetScale()
{
    return Vector2Int(m_renderPosition.w, m_renderPosition.h);
}

Rectangle Object::GetRect()
{
    return m_renderPosition;
}

float Object::GetRotation(){
    return m_rotation;
}

//* Setters *//

void Object::SetPos(Vector2 move)
{
    m_renderPosition.x += move.x;
    m_renderPosition.y += move.y;
}

void Object::SetScale(Vector2Int set){
    m_renderPosition.w = set.x;
    m_renderPosition.h = set.y;
}

void Object::SetRotation(float rotation){
    m_rotation = rotation;
}

//* Object capabilities *//
void Object::Render(SDL_Renderer* r)
{
    SDL_SetRenderDrawColor(r, m_renderColor.r, m_renderColor.g, m_renderColor.b, m_renderColor.a);
    SDL_FRect rect = m_renderPosition;
    SDL_RenderCopyExF(r, m_texture, NULL, &rect, m_rotation, NULL, SDL_FLIP_NONE);
}
