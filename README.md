2018 12 14      --吕

成就系统完成

【NOTICE】

成就触发方法：当达到了触发条件时，调用 GameManager.gm.UnlockAchievement(int num);

其中，num ∈ [1,6],为成就的序号,顺序与策划文档里一致；

不需要判断成就是否已经触发过，直接调用上述函数即可；

如果运行时成就提示框与场景内道具相碰导致位移，需要把相关道具的Layer设置为Tools。


2018 12 09 

新增脚本TriggeredByItemChangeState.cs 结合 PickUpAndDrag.cs 使用

NeedItem中放入交互道具，IntoState放入切换到的状态，变量均为GameObject类型。

WaitAnimaTime栏为动画等待时间。



目前拖拽的道具刚体（rigidbody）属性设为static来避免拖拽过程和其他碰撞区交互

level5 TODO：

交互时附带条件（老爸没有离开的时候不能拆机箱 给TriggeredByItemChangeState.cs加个锁，父亲离开之后sendmessage 释放锁

老妈发火的时候让老爸状态改变 MessageChangeState.cs
