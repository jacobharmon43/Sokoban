#ifndef RECTANGLE_H
#define RECTANGLE_H

#include <SDL.h>
#include "Vector2.h"
#include "Vector2Int.h"

class Rectangle{
    public:
        int x;
        int y;
        int w;
        int h;

        Rectangle();
        Rectangle(int X, int Y, int width, int height);
        Rectangle(Vector2Int point, Vector2Int scale);
        Rectangle(const Rectangle& r);

        bool Contains(Vector2 point);
        bool Intersects(Rectangle b);

        operator SDL_Rect() const;

};

#endif