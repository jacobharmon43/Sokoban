namespace Sokoban
{
    public struct Level{
        public string title;
        public string LevelCode;

        public Level(string title, string LevelCode){
            this.title = title;
            this.LevelCode = LevelCode;
        }

        public static implicit operator string(Level l){
            return $"{l.title}";
        }
    }

    public static class Levels{
        public static readonly Level[] levels = new Level[]{
          new Level(
            "Laser tutorial",
            @"######(L(va))#(L(va))###
              #.(Sa)......(B).(H)#
              #.(B)......(B).(H)#
              #.(P)......(B).(H)#
              #.......(B).(H)#
              #.......(B).(H)#
              ##########"
          ),
          new Level(
              "I stole this from the original Sokoban game!",
              @"##########
                ###...####
                #.(H).(P).(B)..####
                ## # . .(B) .(H) ####
                #.(H)##.(B).####
                #.#..(H).####
                #.(B)..(H(B)).(B).(B).(H)###
                #....(H)..###
                ##########
                ##########"
          )
        };
    }
}
