-- 1 -- CRIAR O BANCO DE DADOS
CREATE DATABASE programacao_do_zero;

-- USAR O BANCO
USE programacao_do_zero;

-- CRIAR TABELA DO USUÁRIO
CREATE TABLE usuario (

    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(150) NOT NULL,
    telefone VARCHAR(15)NOT NULL,
    email VARCHAR(50)NOT NULL,
    genero VARCHAR(20)NOT NULL,
    senha VARCHAR(30)NOT NULL,
    PRIMARY KEY (id)
);
-- CRIAR TABELA ENDEREÇO
CREATE TABLE endereco (
id INT NOT NULL AUTO_INCREMENT,
rua VARCHAR(250) NOT NULL,
numero VARCHAR(30) NOT NULL,
bairro VARCHAR(150) NOT NULL,
cidade VARCHAR(250) NOT NULL,
complemento VARCHAR(9) NULL,
cep VARCHAR(9) NOT NULL,
estado VARCHAR(2) NOT NULL,
PRIMArY KEY (id)
);

-- ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

--Esse comando cria uma chave estrangeira que vincula a tabela endereco à tabela usuario,
--garantindo que todo endereço pertença a um usuário válido e já cadastrado.
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--INSERIR USUÁRIOS
INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES 
('Fernando', 'Barbosa', '(61) 98654-7833','fernando.ads.bsb@gmail.com', 'Masculino', '123')

INSERT INTO usuario
(nome, sobrenome, telefone, email, genero, senha) 
VALUES 
('Nayelle', 'Ramos', '(61) 98654-1234','nayelle.ramos@gmail.com', 'Feminino', 'teste123')


-- SELECIONAR TODOS OS USUÁRIOS  
SELECT * FROM usuario;

--SELECIONAR APENAS 1 USUÁRIO
SELECT * FROM usuario WHERE email = 'fernando.ads.bsb@gmail.com';

--ALTERAR UM USUARIO
UPDATE usuario SET email = 'fernandomenezes@gmail.com' WHERE id = 1;

--EXCLUIR USUARIO
DELETE FROM usuario WHERE id = 3;

--APAGAR MAIS DE 1 USUÁRIO
DELETE FROM usuario WHERE id IN (5,7);