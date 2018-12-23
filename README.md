**2018 12 23**

替换 win/fail音效

添加 门锁音效

替换 第五关switch音效

调整 页面按键比例

调整 第一关灯泡图层

DEBUG 第五关能够同时成功失败



**2018 12 21**

修改了左右移动按钮图样

修改了暂停菜单尺寸比例问题

被电 / 神出现动画

倒水倒油动画

边缘按钮隐藏（主界面和游戏内房间）

到处添加音效



**2018 12 16**

<font color=red>触发老妈成就那个我觉得怪怪的因为没有对应的动画我只好加了个字幕</font>

**【功能】**现在初始界面的reset按钮可以重置成就进度，方便测试

**【修改与新增脚本】**

ChangeStateOnClick.cs 现在可以处理“因为某些原因打不开（会有系统提示）”和“不能再次切换状态”（比如柜子门打开就不能关上了）则两种情况

ChangeStateTogether.cs 用来处理两个状态切换同时发生，比如沙发上的老爸在发火老妈出现后就会光速切换为哭泣老爸。

fadeout.cs 处理系统提示字幕的淡出效果。

GameClearCheck.cs 加在GameManager上用SendMessage形式调用它的函数GameClear()可以帮你处理“切换页面禁止”“替换明暗场景”“等待一段时间让游戏通关”这三个操作。调用SetFailed()同理。

SystemAnnoucement.cs 用来在点击时间发生时发出一个系统通知，需要UI文本框对象。

TriggeredByItemChangeState.cs 加了几个变量用来处理把ns给老妈的成就，不影响一般使用。

其他脚本我都瞎做着玩的。

**【TODO】**

第三关绝赞制作中

音效添加需要



**2018 12 14**


成就系统完成

**【NOTICE】**

成就触发方法：当达到了触发条件时，调用 GameManager.gm.UnlockAchievement(int num);

其中，num ∈ [1,6],为成就的序号,顺序与策划文档里一致；

不需要判断成就是否已经触发过，直接调用上述函数即可；

如果运行时成就提示框与场景内道具相碰导致位移，需要把相关道具的Layer设置为Tools。



**2018 12 09** 

**新增脚本**TriggeredByItemChangeState.cs 结合 PickUpAndDrag.cs 使用

NeedItem中放入交互道具，IntoState放入切换到的状态，变量均为GameObject类型。

WaitAnimaTime栏为动画等待时间。

目前拖拽的道具刚体（rigidbody）属性设为static来避免拖拽过程和其他碰撞区交互


