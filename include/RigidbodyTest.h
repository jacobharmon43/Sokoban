#ifndef RIGIDBODYTEST_H
#define RIGIDBODYTEST_H

#include <iostream>
#include "JHEngine.h"

class RigidbodyTest : public Game{
    public:
        RigidbodyTest();
        RigidbodyTest(int width, int height);
        ~RigidbodyTest();

        void Init(const char* name);
        bool Update();
        void Draw();
        void Close();
    private:
        Object m_floor;
        Rigidbody* m_box;
        int m_gravity;
        bool PollKeyboard(const Uint8* input);
};

#endif 