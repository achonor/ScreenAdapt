# ScreenAdapt
Unity UGUI 横竖屏切换自适应方案

AdaptManager挂到场景

针对不同的Component使用不同的脚本

非运行状态下切换分辨率后点击菜单上的Achonor->ApplyAdaptScreen让UI重新适配屏幕

继承自AdaptBase的类包含两个属性LandscapeConfig, PortraitConfig分别是横屏配置和竖屏配置，UI拼好之后可以在Inpsector中右键对应属性然后点击Copy Property将UI的属性拷贝到对应的配置中

Editor扩展的用法可以看这里https://blog.csdn.net/AcmHonor/article/details/107836995
