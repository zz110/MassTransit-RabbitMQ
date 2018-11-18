# MassTransit-RabbitMQ  
## .NET使用MassTransit消息总线集成RabbitMQ实现发布订阅

1. RabbitMQClient  
      > 客户端,消费服务端 PrintMessage,RoadGateMessage消息
2. RabbitMQServer  
      > 服务端,向所有客端发布 PrintMessage,RoadGateMessage 消息,同时消费客户端 CameraMessage,TruckScaleMessage 消息
3. RabbitMQMessageDefinition  
      > 消息定义、事件通知
4. RabbitMQManager  
      > RabbitMQ管理,包括消费配置,MassTransit消息总线配置,UnityContainer,日志管理

# 相关配置文件说明

1. Consumer.config 消费者配置
    > name         必须参数且唯一    
    > queue_name   队列名称 发布订阅模式下客户端不需要配置,服务端需要配置    
    > classname    消费者类全名称
    
2. RabbitMQ.config RabbitMQ 连接参数配置
   > Host rabbitmq连接IP地址  
   > Username rabbitmq连接用户名 
   > Password rabbitmq连接密码


# windows下安装RabbitMQ

1. 准备安装资源文件
    - erlang
        + otp_win64_20.1.exe
        + 下载地址:http://www.erlang.org/downloads/20.1
    - rabbitmq
        + rabbitmq-server-windows-3.6.13.zip
        + 下载地址:https://github.com/rabbitmq/rabbitmq-server/releases/tag/rabbitmq_v3_6_13
	  
2. 配置环境变量
   - ERLANG_HOME        
        + erlang安装路径 如:D:\erl9.1
   - RABBITMQ_BASE      
      + 如:D:\data\RabbitMQ 此基础目录包含了RabbitMQ server的数据库,日志文件的子目录。另外,也可以独立设置RABBITMQ_MNESIA_BASE 和 RABBITMQ_LOG_BASE 目录 RABBITMQ_BASE 
      + 参考:http://www.blogjava.net/qbna350816/archive/2016/08/02/431415.aspx
   - RABBITMQ_SERVER    
        + rabbiqmq 解压或安装目录 如:D:\Program Files\RabbitMQ\rabbitmq_server-3.6.13
        + 修改PATH环境变量添加如下值
           > ;%ERLANG_HOME%\bin                   
           > ;%RABBITMQ_SERVER%\sbin
        + 如果以上配置不起作用改 
           > D:\erl9.1\bin 	  
           > D:\Program Files\RabbitMQ\rabbitmq_server-3.6.13\sbin
3. 启用rabbitmq服务 
   - rabbitmq-service install
   - rabbitmq-service enable
   - rabbitmq-service start
4. 用户管理
   - rabbitmqctl  add_user  {您的rabbitmq用户名}  {设置的密码}
   - rabbitmqctl  set_permissions  {您的rabbitmq用户名}  ".*"  ".*"  ".*"
   - rabbitmqctl  set_user_tags {您的rabbitmq用户名} administrator
   - rabbitmqctl  delete_user guest
   - rabbitmq-plugins enable rabbitmq_management
5. 拷贝 C:\Windows\\.erlang.cookie 到 当前用户文件夹下 如:C:\Users\Administrator
6. 用您的rabbitmq的用户名、密码 填充 config/RabbitMQ.config 用户名、密码,并设置rabbitmq IP地址

7. 参考:
    > http://www.cnblogs.com/yangecnu/p/Introduce-RabbitMQ.html
    > http://www.blogjava.net/qbna350816/archive/2016/08/02/431415.aspx
