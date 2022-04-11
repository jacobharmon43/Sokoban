#ifndef RECTANGLE_H
#define RECTANGLE_H

#include <SDL.h>
#include "Vector2.h"
#include "Vector2Int.h"

class Rectangle{
    public:
        double x;
        double y;
        double w;
        double h;

        Rectangle();
        Rectangle(double X, double Y, double width, double height);
        Rectangle(Vector2Int point, Vector2Int scale);
        Rectangle(const Rectangle& r);

        bool Contains(Vector2 point);
        bool Intersects(Rectangle b);

        operator SDL_Rect() const;
        operator SDL_FRect() const;

};

#endif