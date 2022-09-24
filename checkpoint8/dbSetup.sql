CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  img VARCHAR(255) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  kept INT NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

INSERT INTO keeps
(creatorId, name, description, img, views, kept)
VALUES
('63289a99b1a60e1497f3f2e9', 'MrBeast', 'This is totally awesome', 'https://helios-i.mashable.com/imagery/articles/00AxnPvg6PSo6ToUtjc7YVr/hero-image.fill.size_1200x1200.v1650398912.png', 100, 1 );

INSERT INTO keeps
(creatorId, name, description, img, views, kept)
VALUES
('632de6501a80ce4093cc1c84', 'Dude Perfect', 'We make it on our first time, every time!', 'https://2018media.idtech.com/images/blog/featured/1624549672_dude-perfect.jpg?3bda24a9b9', 150, 2);

CREATE TABLE vaultkeeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  vaultId INT NOT NULL,
  keepId INT NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  FOREIGN KEY (keepId) REFERENCES keeps(id),
  FOREIGN KEY (vaultId) REFERENCES vaults(id)
) default charset utf8 COMMENT '';

CREATE TABLE vaults(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  isPrivate BOOLEAN,

  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

  SELECT
  k.*,
  a.*
  FROM keeps k
  JOIN accounts a ON k.creatorId = a.id;
           

  SELECT
  k.*,
  a.*
  FROM keeps k
  JOIN accounts a ON k.creatorId = a.id
  WHERE k.id = @id;

  UPDATE keeps SET
  name = @Name,
  description = @Description,
  img = @Img,
  views = @Views,
  kept = @Kept
  WHERE id = @Id;

  DELETE FROM keep WHERE id = @id;