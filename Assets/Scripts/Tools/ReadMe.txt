Vector3Extensions: (EnemyMover to)
IsEnoughClose => private bool IsTargetReached(Transform targetPoint, float minDistance)
{return transform.position.IsEnoughClose(targetPoint.position, minDistance);}
проверяем дистанцию через булку, что если расстояние МЕЖДУ текущей позицией и таргетом МЕНЬШЕ мин дистанции - то ДА,
иначе нет
вроде как для оптимизации (точности?), еще почитать


PlayerAnimatorData
нужно для управления анимацией, оптимизация

RotationDisable - в данном случае будет возвращать изначальное положение по оси на то, которое было при старте.
можно будет использовать повторно (главное не забыть где оно лежит) на врагах если у них будет ассиметричный спрайт