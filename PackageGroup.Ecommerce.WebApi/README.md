**REDIS**

>> Para ejecutar la imagen redis:
>> >> docker run -d --name redis-stack -e REDIS_ARGS="--requirepass 123456" -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
