#ifndef VECTOR2INT_H
#define VECTOR2INT_H

#include <cmath>
#include "Vector2.h"

class Vector2Int{
    public:
        int x;
        int y;
        Vector2Int();
        Vector2Int(int X, int Y);
        Vector2Int(float X, float Y);
        Vector2Int(const Vector2Int &b);
        ~Vector2Int();
        int SqrDistance(const Vector2Int& a, const Vector2Int& b);
        bool operator ==(Vector2Int b);
        bool operator !=(Vector2Int b);
        Vector2Int Reflect(Vector2Int line);
        Vector2Int Perpendicular();
        Vector2Int Normalize();
        int Dot(Vector2Int vector);

        //Vector2Int operations
        Vector2Int& operator =(Vector2Int b);
        Vector2Int operator +(Vector2Int b);
        Vector2Int operator -(Vector2Int b);
        Vector2Int operator *(Vector2Int b);
        Vector2Int operator /(Vector2Int b);
        Vector2Int& operator +=(Vector2Int b);
        Vector2Int& operator -=(Vector2Int b);
        Vector2Int& operator *=(Vector2Int b);
        Vector2Int operator /=(Vector2Int b);

        //Scalar operations
        Vector2Int& operator =(int b);
        Vector2Int operator +(int b);
        Vector2Int operator -(int b);
        Vector2Int operator *(int b);
        Vector2Int operator /(int b);
        Vector2Int& operator +=(int b);
        Vector2Int& operator -=(int b);
        Vector2Int& operator *=(int b);
        Vector2Int& operator /=(int b);

        operator Vector2() const;
};

#endif