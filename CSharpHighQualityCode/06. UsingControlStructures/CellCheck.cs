bool xCondition = MIN_X <= x && x <= MAX_X;
bool yCondition = MIN_Y <= y && y <= MAX_Y;

if (xCondition && yCondition && shouldVisitCell)
{
   VisitCell();
}