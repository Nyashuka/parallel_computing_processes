with Ada.Text_IO;
with Ada.Integer_Text_IO;
procedure Main is

   can_stop : array(1..5) of Boolean := (others => False);

   pragma Atomic (can_stop);
   coll_thread : Integer := 5;

   task type thread_breaker is
      entry Init(timein : Duration; idin : Integer);
   end thread_breaker;

   task type calculator is
      entry Init(stepin : Long_Long_Integer; idin : Integer);
   end calculator;

   task body thread_breaker is
      time : Duration;
      id :Integer;
   begin
      accept Init(timein : in Duration; idin : in Integer) do
         begin
            time := timein;
            id := idin;
         end;
      end Init;

      delay time;
      can_stop(id) := True;
   end thread_breaker;

   task body calculator is
      steps_count  : Long_Long_Integer := 0;
      sum  : Long_Long_Integer := 0;

      step : Long_Long_Integer;
      id : Integer;
   begin
      accept Init(stepin : in Long_Long_Integer; idin : in Integer) do
         begin
            step := stepin;
            id := idin;
         end;
      end Init;
      loop
         steps_count := steps_count + 1;
         sum := sum + step;
         exit when can_stop(id);
      end loop;
      Ada.Text_IO.Put_Line ("Id: " & Id'Img & " | steps: " & steps_count'Img & " | sum: " & sum'Img);
   end calculator;

   durations : array (1 .. 5) of Standard.Duration := (3.0, 2.0, 1.0, 1.5, 0.5);
   calculators   : array (1 .. coll_thread) of calculator;
   thread_breakers   : array (1 .. coll_thread) of thread_breaker;
   steps   : array (1 .. coll_thread) of Long_Long_Integer := (1, 2, 3, 4, 5);
begin
   for I in calculators'Range loop
      calculators(I).Init(steps(I), i);
      thread_breakers(I).Init(durations(I), i);
   end loop;

end Main;
