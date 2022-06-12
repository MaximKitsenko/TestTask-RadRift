# Quickstart

## Run.RadRiftGame.Api

## CreateNew game
POST http://localhost:5030/api/game/create
```json
{
"Name":"game-name",
"HostUserId":"11111111-1111-1111-1111-111111111111"
}
```

## Get games with users count
GET http://localhost:5030/api/game/list
result:
```json
{
    "c6f3b1ba-9bb5-409c-aa93-097e36406d2b": 1
}
```

## Join user to game
POST http://localhost:5030/api/game/join

```json
{
  "GameRoomId":"c6f3b1ba-9bb5-409c-aa93-097e36406d2b",
  "UserId":"aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"
}
```

## Get game status
GET http://localhost:5030/api/game/c6f3b1ba-9bb5-409c-aa93-097e36406d2b
Result:
```json
Game: c6f3b1ba-9bb5-409c-aa93-097e36406d2b, HostHealth: 0, player1Health:4, status:Stoped
```

## Check r~~~~eport in DB 
GamesResults table