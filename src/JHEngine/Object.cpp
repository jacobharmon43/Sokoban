#include "Object.h"

Object::Object(){}
Object::~Object() {}

Object::Object(Rectangle renderPosition, SDL_Color renderColor, int renderOrder)
{
    m_renderPosition = renderPosition;
    m_renderColor = renderColor;
    m_renderOrder = renderOrder;
}

void Object::Move(Vector2 move)
{
    m_renderPosition.x += move.x;
    m_renderPosition.y += move.y;
}

void Object::SetScale(Vector2Int set){
    m_renderPosition.w = set.x;
    m_renderPosition.h = set.y;
}

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

void Object::Render(SDL_Renderer* r)
{
    SDL_SetRenderDrawColor(r, m_renderColor.r, m_renderColor.g, m_renderColor.b, m_renderColor.a);
    SDL_Rect rect = m_renderPosition;
    SDL_RenderFillRect(r, &rect);
}
