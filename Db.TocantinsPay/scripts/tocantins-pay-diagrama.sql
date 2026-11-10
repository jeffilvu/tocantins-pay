CREATE TABLE "cliente" (
  "id" uuid PRIMARY KEY,
  "nome_completo" varchar(150) NOT NULL,
  "situacao" smallint NOT NULL,
  "email" varchar(255) UNIQUE NOT NULL,
  "cpf" varchar(14) UNIQUE NOT NULL,
  "data_nascimento" date NOT NULL,
  "telefone" varchar(20) NOT NULL,
  "senha" varchar(255) NOT NULL
);

CREATE TABLE "endereco" (
  "id" uuid PRIMARY KEY,
  "cep" char(9) NOT NULL,
  "logradouro" varchar(200) NOT NULL,
  "bairro" varchar(100) NOT NULL,
  "cidade" varchar(100) NOT NULL,
  "uf" char(2) NOT NULL,
  "cliente_id" uuid NOT NULL
);

CREATE TABLE "carteira" (
  "id" uuid PRIMARY KEY,
  "saldo" decimal(15,2) NOT NULL,
  "conta" varchar(50) NOT NULL,
  "agencia" varchar(10) NOT NULL,
  "cliente_id" uuid NOT NULL
);

CREATE TABLE "transacao" (
  "id" uuid PRIMARY KEY,
  "tipo" smallint NOT NULL,
  "data" timestamptz NOT NULL,
  "valor" decimal(15,2) NOT NULL,
  "saldo_resultante" decimal(15,2) NOT NULL,
  "descricao" varchar(150),
  "carteira_id" uuid NOT NULL,
  "cofrinho_id" uuid
);

CREATE TABLE "cofrinho" (
  "id" uuid PRIMARY KEY,
  "nome" varchar(100) NOT NULL,
  "saldo" decimal(15,2) NOT NULL,
  "meta" decimal(15,2),
  "carteira_id" uuid NOT NULL
);

ALTER TABLE "endereco" ADD FOREIGN KEY ("cliente_id") REFERENCES "cliente" ("id") ON DELETE CASCADE;

ALTER TABLE "carteira" ADD FOREIGN KEY ("cliente_id") REFERENCES "cliente" ("id");

ALTER TABLE "transacao" ADD FOREIGN KEY ("carteira_id") REFERENCES "carteira" ("id");

ALTER TABLE "cofrinho" ADD FOREIGN KEY ("carteira_id") REFERENCES "carteira" ("id");

ALTER TABLE "transacao" ADD FOREIGN KEY ("cofrinho_id") REFERENCES "cofrinho" ("id");
