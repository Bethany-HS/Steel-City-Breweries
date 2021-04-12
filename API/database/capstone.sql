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
	user_role varchar(50) NOT NULL,
	name varchar (50) not null
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE breweries (
	brewery_id int IDENTITY(1,1) NOT NULL,
	name varchar(50) NOT NULL,
	brewer_id int NOT NULL,
	street_address1 nvarchar(100)not null,
	street_address2 nvarchar(50) null,
	city varchar (50) not null,
	state varchar (2) not null,
	zip int not null,
	phone varchar (15) not null,
	history nvarchar(300) not null,
	hours_of_operation varchar(300) not null,
	website varchar(30) not null,
	brewery_status_id int not null	
	CONSTRAINT PK_brewery PRIMARY KEY (brewery_id)
);
Create Table brewery_status_id (
	brewery_status_id int IDENTITY(1,1),
	brewery_status_desc varchar(10) not null
	Constraint PK_brewery_status PRIMARY KEY (brewery_status_id)
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
	name varchar(50) not null,
	abv decimal(4,2) NOT NULL,
	description varchar(500) NOT NULL,
	ingredients varchar(200) NOT NULL,
	isActive bit not null
	CONSTRAINT PK_beer_id PRIMARY KEY (beer_id)
);

CREATE TABLE beer_types (
beer_type_id int IDENTITY(1,1) NOT NULL,
beer_type varchar(75) NOT NULL
CONSTRAINT PK_beer_type PRIMARY KEY (beer_type_id)
);

CREATE TABLE brewery_reviews (
brewery_review_id int IDENTITY(1,1) NOT NULL,
brewery_id int not null,
user_id int not null,
title varchar(100) NOT NULL,
review varchar(300) NOT NULL,
rating int NOT NULL,
is_private bit Not Null
CONSTRAINT PK_brewery_review_id PRIMARY KEY (brewery_review_id)
);

CREATE TABLE beer_reviews(
beerReview_id int IDENTITY (1,1) not null,
beer_id int not null,
user_id int not null,
beerRating int not null,
title varchar(100) NOT NULL,
beerReview varchar(300) not null,
is_private bit Not Null
CONSTRAINT PK_beerReview_id PRIMARY KEY (beerReview_id)
);
ALTER TABLE breweries ADD CONSTRAINT fk_brewer_id FOREIGN KEY (brewer_id) REFERENCES users(user_id);

ALTER TABLE users_favBreweries ADD CONSTRAINT fk_users_favBreweries_users FOREIGN KEY (user_id) REFERENCES users(user_id);

ALTER TABLE users_favBreweries ADD CONSTRAINT fk_users_favBreweries_brewery FOREIGN KEY (brewery_id) REFERENCES breweries(brewery_id);

ALTER TABLE beers ADD CONSTRAINT fk_brewery_id FOREIGN KEY (brewery_id) REFERENCES breweries(brewery_id);

ALTER TABLE beers ADD CONSTRAINT fk_beer_type_id FOREIGN KEY (beer_type_id) REFERENCES beer_types(beer_type_id);
Alter Table beer_reviews ADD CONSTRAINT fk_beerReview_beer_id FOREIGN KEY (beer_id) REFERENCES beers(beer_id);
ALTER TABLE beer_reviews ADD CONSTRAINT fk_beerReview_user_id FOREIGN KEY (user_id) REFERENCES users(user_id);

ALTER TABLE brewery_reviews ADD CONSTRAINT fk_breweryReview_brewery_id FOREIGN KEY (brewery_id) REFERENCES breweries(brewery_id);
ALTER TABLE brewery_reviews ADD CONSTRAINT fk_breweryReview_user_id FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE  breweries ADD CONSTRAINT fk_brewery_status_id FOREIGN KEY (brewery_status_id) REFERENCES brewery_status_id(brewery_status_id);
commit transaction
--populate default data
INSERT INTO users (username, password_hash, salt, user_role, name) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'user');
INSERT INTO users (username, password_hash, salt, user_role, name) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'admin');


INSERT INTO brewery_status_id (brewery_status_desc) values ('pending');
INSERT INTO brewery_status_id (brewery_status_desc) values ('active');
INSERT INTO brewery_status_id (brewery_status_desc) values ('inactive');

INSERT INTO breweries (name, brewer_id, street_address1, city, state, zip, phone, history, hours_of_operation, website, brewery_status_id) 
values ('Penn Brewery', 1, '800 Vinial Street', 'Pittsburgh', 'PA', '15212', '412-237-9400', 'Began brewing craft beer since 1986. We started brewing classic lagers and
German beer styles.  Our Restaurant serves Pittsburgh Native foods.  See our site for more details.', 'Weds-Sat: Noon - 10pm Sun: Noon - 9pm Closed Mon-Tues', 'https://www.pennbrew.com', 1);

INSERT INTO breweries (name, brewer_id, street_address1, city, state, zip, phone, history, hours_of_operation, website, brewery_status_id) 
values ('Southern Tier Brewing Co', 1, '316 N. Shore Drive', 'Pittsburgh', 'PA', '15212', '412-301-2337', '"Sothern Tier Brewering Companys first satellite brewpub.  
Were known for brewing world-class hoppy ales and decadent dessert beers alike, but we are known for the experience customers have when they visit.', 
'Mon-Wed: 3 - 10pm, Thur: 11 am - 10pm, fri-sat: 11am - 12am, sun 11am - 10pm"', 'https://taprooms.stbcbeer.com', 1);

Insert Into beer_types (beer_type) values('Ale');
Insert Into beer_types (beer_type) values('Lager');
Insert Into beer_types (beer_type) values('IPA');
Insert Into beer_types (beer_type) values('Stout');
Insert Into beer_types (beer_type) values('Pilsner');
Insert Into beer_types (beer_type) values('Porter');
Insert Into beer_types (beer_type) values('Wheat');

INSERT INTO beers (name, abv, brewery_id, beer_type_id, description, ingredients, isActive) VALUES ('Penn Pilsner', 5.0, 1, 5, 
'Our flagship beer. Amber-colored with a malty nose and a touch of Nobel hops, Penn Pilsner has caramel and toffee notes as 
well as toasted, nutty hints.  Penn Pilsner is a very well-rounded, balanced, and flavorful lager beer.', 'Hops: Hallertau Perle, Hallertau Tradition
Malt: Two-row, caramel', 1);

INSERT INTO beers (name, abv, brewery_id, beer_type_id, description, ingredients, isActive) VALUES ('Penn Dark', 5.0, 1, 2, 
'European-style Dark/Munchener Dunkel. Deep reddish-mahogany in color with sweet caramel malt, nutty and toffee notes, and roasted hints.
Penn Dark has a moderate hopping rate and a crisp, clean lager beer finish. A surprisingly smooth dark beer.', 'Hops: Perle, Malt: Two-row, Munich, Carafa', 1);

INSERT INTO beers (name, abv, brewery_id, beer_type_id, description, ingredients, isActive) VALUES ('Across the Spectrum IPA', 6.5, 2, 3, 
'Hazy & Juicy IPA','hops', 1);

INSERT INTO beers (name, abv, brewery_id, beer_type_id, description, ingredients, isActive) VALUES ('Pink Guava Milkshake IPA', 6.5, 2, 3, 
'IPA sweetened with lactose milk sugar and pink guava puree','hops, lactose milk sugar, pink guava puree', 1);

GO
