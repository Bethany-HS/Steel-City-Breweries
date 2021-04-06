USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL

BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END


CREATE DATABASE final_capstone
GO

USE final_capstone
GO
begin transaction
--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE breweries (
	brewery_id int IDENTITY(1,1) NOT NULL,
	name varchar(50) NOT NULL,
	brewer_id int NOT NULL,
	beer_id int NOT NULL,
	brewery_review_id int NOT NULL,
	CONSTRAINT PK_brewery PRIMARY KEY (brewery_id)
);

CREATE TABLE users_favBreweries (
	user_id int NOT NULL,
	brewery_id int NOT NULL
	CONSTRAINT PK_users_breweries PRIMARY KEY (user_id, brewery_id)
);

CREATE TABLE beers (
	beer_id int IDENTITY(1,1) NOT NULL,
	brewery_id int NOT NULL,
	beer_type_id int NOT NULL,
	abv decimal(2,2) NOT NULL,
	description varchar(200) NOT NULL,
	ingredients varchar(200) NOT NULL
	CONSTRAINT PK_beer_id PRIMARY KEY (beer_id)
);

CREATE TABLE beer_types (
beer_type_id int IDENTITY(1,1) NOT NULL,
beer_type varchar(75) NOT NULL
CONSTRAINT PK_beer_type PRIMARY KEY (beer_type_id)
);

CREATE TABLE brewery_reviews (
brewery_review_id int IDENTITY(1,1) NOT NULL,
review varchar(300) NOT NULL,
rating int NOT NULL
CONSTRAINT PK_brewery_review_id PRIMARY KEY (brewery_review_id)
);

ALTER TABLE breweries ADD CONSTRAINT fk_brewer_id FOREIGN KEY (brewer_id) REFERENCES users(user_id);

ALTER TABLE breweries ADD CONSTRAINT fk_beer_id FOREIGN KEY (beer_id) REFERENCES beers(beer_id);

ALTER TABLE users_favBreweries ADD CONSTRAINT fk_users_favBreweries_users FOREIGN KEY (user_id) REFERENCES users(user_id);

ALTER TABLE users_favBreweries ADD CONSTRAINT fk_users_favBreweries_brewery FOREIGN KEY (brewery_id) REFERENCES breweries(brewery_id);

ALTER TABLE beers ADD CONSTRAINT fk_brewery_id FOREIGN KEY (brewery_id) REFERENCES breweries(brewery_id);

ALTER TABLE beers ADD CONSTRAINT fk_beer_type_id FOREIGN KEY (beer_type_id) REFERENCES beer_types(beer_type_id);

ALTER TABLE breweries ADD CONSTRAINT fk_brewery_review_id FOREIGN KEY (brewery_review_id) REFERENCES brewery_reviews(brewery_review_id);

commit transaction
--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO