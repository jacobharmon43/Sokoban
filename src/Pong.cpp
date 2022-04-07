#include "Pong.h"

Pong::Pong(){
    m_height = 0;
    m_width = 0;
}

Pong::Pong(int width, int height){
    m_height = height;
    m_width = width;
}

Pong::~Pong(){   }

void Pong::Init(const char* name)
{
    Game::Init(name);
    m_player1 = Object(Rectangle(m_width/20, m_height/2 - 64, 16,128), SDL_Color {48,98,48,255}, 10);
    m_player2 = Object(Rectangle(m_width - m_width/20, m_height/2 - 64, 16,128), SDL_Color {48,98,48,255}, 10);
    m_ball = new Dynamic(Rectangle(m_width/2, m_height/2, 16,16), SDL_Color {155,188,15,255}, 10, Vector2(3,0));
    m_divider = Object(Rectangle(m_width/2 - 8, 0, 16, GetHeight()), SDL_Color {170,170,170,255}, 10);
    m_speed = 3;
}

bool Pong::Update()
{
    m_ball -> Update();
    if(input[SDL_SCANCODE_ESCAPE]){
        return true;
    }
    PollKeyboard(input);
    if(m_ball -> CheckCollision(m_player1)){
        m_speed++;
        Vector2 center = m_player1.GetPos() + Vector2(m_player1.GetScale().x, m_player1.GetScale().y)/2;
        Vector2 ballCenter = m_ball -> GetPos() + m_ball -> GetScale()/2;
        Vector2 next = ((ballCenter - center) / Vector2(16,128)).Normalize() * m_speed;
        Vector2 diff = (ballCenter - center).Normalize();
        m_ball -> SetVelocity(next);
    }
    else if(m_ball -> CheckCollision(m_player2)){
        m_speed++;
        Vector2 center = m_player2.GetPos() + m_player2.GetScale()/2;
        Vector2 ballCenter = m_ball -> GetPos() + m_ball -> GetScale()/2;
        Vector2 next = ((ballCenter - center) / Vector2(16,128)).Normalize() * m_speed;
        Vector2 diff = (ballCenter - center).Normalize();
        m_ball -> SetVelocity(next);
    }
    else if(m_ball -> GetPos().y > (GetHeight() - m_ball -> GetScale().y/2)){
        m_ball -> SetVelocity(m_ball -> GetVelocity() * Vector2(1,-1));
    } 
    else if(m_ball -> GetPos().y < 0){
        m_ball -> SetVelocity(m_ball -> GetVelocity() * Vector2(1,-1));
    }
    else if(m_ball -> GetPos().x < 0){
        m_speed = 3;
        delete m_ball;
        m_ball = new Dynamic(Rectangle(m_width/2, m_height/2, 16,16), SDL_Color {155,188,15,255}, 10, Vector2(-m_speed,0));
    }
    else if(m_ball -> GetPos().x > GetWidth()){
        m_speed = 3;
        delete m_ball;
        m_ball = new Dynamic(Rectangle(m_width/2, m_height/2, 16,16), SDL_Color {155,188,15,255}, 10, Vector2(m_speed,0));
    }
    return false;
}

void Pong::Draw()
{
    Game::Draw();
    m_divider.Render(gRenderer);
    m_player1.Render(gRenderer);
    m_player2.Render(gRenderer);
    m_ball -> Render(gRenderer);
    SDL_SetRenderDrawColor(gRenderer,15,56,15,255);
    SDL_RenderPresent(gRenderer);
}

void Pong::Close()
{
    Game::Close();
}

bool Pong::PollKeyboard(const Uint8* input)
{
    if(input[SDL_SCANCODE_W]){
        m_player1.Move(Vector2(0,-5));
        if(m_player1.GetPos().y < 0) m_player1.Move(Vector2(0,5));
    }
    if(input[SDL_SCANCODE_S]){
        m_player1.Move(Vector2(0,5));
        if(m_player1.GetPos().y > (GetHeight()-m_player1.GetScale().y)) m_player1.Move(Vector2(0,-5));
    }
    if(input[SDL_SCANCODE_UP]){
        m_player2.Move(Vector2(0,-5));
        if(m_player2.GetPos().y < 0) m_player2.Move(Vector2(0,5));
    }
    if(input[SDL_SCANCODE_DOWN]){
        m_player2.Move(Vector2(0,5));
        if(m_player2.GetPos().y > (GetHeight()- m_player2.GetScale().y)) m_player2.Move(Vector2(0,-5));
    }
    return false;
}
