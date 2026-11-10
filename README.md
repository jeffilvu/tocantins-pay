### Necessário

- Ter o docker configurado na máquina.

- Ter a rede docker "tocantinspay-network" criada. Caso não esteja criada, pode-se criar rodando manualmente o comando:

```
docker network create --driver bridge tocantinspay-network
```

### Para executar o container

```
docker-compose up
```

### Para remover o container

```
docker-compose down
```

### Para remover o container e o volume

```
docker-compose down -v
```