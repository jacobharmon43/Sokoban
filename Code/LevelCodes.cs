namespace Sokoban
{
    public struct Level{
        public string title;
        public string TileCode;
        public string ObjectCode;

        public Level(string title, string TileCode, string ObjectCode){
            this.title = title;
            this.TileCode = TileCode;
            this.ObjectCode = ObjectCode;
        }

        public static implicit operator string(Level l){
            return $"{l.title}";
        }
    }

    public static class Levels{
        public static Level[] levels = new Level[]{
            new Level(
                "I stole this from the original Sokoban game!",
                @"# # # # # # # # ##
                # # # . . . # # ##
                # . . . . . # # ##
                # # # . . . # # ##
                # . # # . . # # ##
                # . # . . . # # ##
                # . . . . . . # ##
                # . . . . . . # ##
                # # # # # # # # ##
                # # # # # # # # ##",
                @". . . . . . . . ..
                . . . . . . . . ..
                . H P B . . . . ..
                . . . . B H . . ..
                . H . . B . . . ..
                . . . . H . . . ..
                . B . H ( B ) B BH. . .
                . . . . H . . . ..
                . . . . . . . . ..
                . . . . . . . . .."
            ),
          new Level(
              "Waluigi Confirmed?",
              @"# # # # # # # # # #
                # # # # . . # # # #
                # # # # . . # # # #
                # # # # . . # # # #
                # # # # . . # # # #
                # . . . . . # # # #
                # . . . . . # # # #
                # # # # # # # # # #
                # # # # # # # # # #
                # # # # # # # # # #",
              @". . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . B H . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . P B H . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . ."
          ),
          new Level(
              "The good level 3",
              @"# # # # # # # # # #
                # # # # # # # # # #
                # # # # # # # # # #
                # . . . . # # # # #
                # . . . . . . # # #
                # # # . . . . # # #
                # # # . . . . # # #
                # # # # # # # # # #
                # # # # # # # # # #
                # # # # # # # # # #",
              @". . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . H P . B . . . . .
                . . . B B B . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . ."
          ),
          new Level(
              "Lazerzzzz",
              @"# # # # # # # # # #
                # # . . . . . . # #
                # # . . . . . . # #
                # # . . . . . . # #
                # # . . . . . . . #
                # # . . # . . . # #
                # . . . # . . . . #
                # . . . # . . . # #
                # . . . # . . . # #
                # # # # # # # # # #",
              @". . . . . . . . . .
                . . . . . . . . . .
                . . . . . . . . . .
                . . . . . . B . . .
                . . . . O . . . L(<) .
                . . . . . . . . . .
                . . . . . . . . L(<) .
                . . B . . B . . . .
                . P . . . H . . . .
                . . . . . . . . . ."
          )
        };
    }
}
