namespace Sokoban
{
     public readonly struct Level
    {
        public readonly string Title;
        public readonly string LevelCode;
        public readonly string Objective;

        public Level(string Title, string LevelCode, string Objective){
            this.Title = Title;
            this.LevelCode = LevelCode;
            this.Objective = Objective;
        }
    }
    
    public static class Levels{

        public static int LevelIndex = 0;

        public static Level[] All = new Level[]{
            new Level(
                "I Promise this Level is Beatable",
                @"##############
                  #..(T)#......#.(T).#
                  #..#..##..#..#
                  #..#......#..#
                  #.....(Q^).......#
                  #.....(B).......#
                  #.(G).(G)..#..#..(Q<).(G).(G)#
                  #....#..#....#
                  #....#..#....#
                  #..(Q>)..#..#....#
                  #....#..#....#
                  #............#
                  #.(P)...........#
                  #######(L^)#(L^)######",
                "Destroy the targets!"
            ),
            new Level(
                "Tutorial",
                @"##############
                  ##############
                  ##############
                  ##############
                  ##############
                  ####.(H)..(B)..(H)#####
                  ####..(B).(P).(B).#####
                  ####.(H)..(B)..(H)#####",
                "Sort every box onto a green highlighted tile"
            ),
            new Level(
                "Laser tutorial",
                @"##############
                  ##############
                  ####......####
                  ####......####
                  ####.....(B).####
                  ####...(G)...#(L<)###
                  ####..#...####
                  ###...#...#(L<)###
                  ###..(B).##..####
                  ###.(P)..##..(F)####",
                "Reach the flag!"
            ),
            new Level(
                "Confusing?",
                @"##############
                  ##############
                  ##############
                  ##############
                  ###....#######
                  ###.(P).(H)..(B)..#####
                  #####.(B).(B).(B).#####
                  #####....#####",
                "Sort a box!"
            ),
            
        };

    }
}
