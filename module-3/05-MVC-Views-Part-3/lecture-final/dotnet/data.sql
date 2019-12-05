
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the TEgram Database (IF EXISTS)
DROP DATABASE IF EXISTS TEgram;
GO

-- Create a new TEgram Database
CREATE DATABASE TEgram;
GO

-- Switch to the TEgram Database
USE TEgram
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE posts
(
	id			int				identity,
	username	varchar(20)		not null,
	userImage	varchar(200)	not null,
	postImage	varchar(200)	not null,
	likes		int				not null default(0),
	hasBeenLiked bit			not null default(0),
	caption		nvarchar(100),
);

INSERT INTO posts(username,userImage,postImage,likes,hasBeenLiked,caption) VALUES ('socleansofreshh','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/me_3.jpg','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/tropical_beach.jpg',1031,0,N'When you''re ready for summer ☀️');
INSERT INTO posts(username,userImage,postImage,likes,hasBeenLiked,caption) VALUES ('djirdehh','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/me2.png','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/downtown.jpg',20,1,N'Views from the six...');
INSERT INTO posts(username,userImage,postImage,likes,hasBeenLiked,caption) VALUES ('puppers','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/pug_personal.jpg','https://s3-us-west-2.amazonaws.com/s.cdpn.io/1211695/puppers.jpg',49,0,N'Current mood 🐶');
INSERT INTO posts(username,userImage,postImage,likes,hasBeenLiked,caption) VALUES ('legoman','https://randomuser.me/api/portraits/lego/2.jpg','https://inhabitat.com/files/2010/03/Jan-Vormann-Lego-Brick.jpg',1632,0,N'Inspired....😍');

COMMIT TRANSACTION;