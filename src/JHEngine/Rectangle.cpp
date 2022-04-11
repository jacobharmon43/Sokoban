#include "Rectangle.h"

Rectangle::Rectangle()
{
    x,y,w,h = 0;
}

Rectangle::Rectangle(int X, int Y, int width, int height)
{
    x = X;
    y = Y;
    w = width;
    h = height;
}

Rectangle::Rectangle(Vector2Int point, Vector2Int scale)
{
    x = point.x;
    y = point.y;
    w = scale.x;
    h = scale.y;
}

Rectangle::Rectangle(const Rectangle& r)
{
    x = r.x;
    y = r.y;
    w = r.w;
    h = r.h;
}

Rectangle::operator SDL_Rect() const
{
    return SDL_Rect {x,y,w,h};
}

Rectangle::operator SDL_FRect() const
{
    return SDL_FRect {(float)x,(float)y,(float)w,(float)h};
}

bool Rectangle::Contains(Vector2 point){
    return point.x >= x && point.x <= x+w && point.y >= y && point.y <= y+h;
}

bool Rectangle::Intersects(Rectangle b){
    SDL_Rect c = Rectangle(x,y,w,h);
    SDL_Rect d = b; 
    return SDL_HasIntersection(&c, &d);
}