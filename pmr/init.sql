create table categories
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	image_path text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table doctors
(
	id bigint generated always as identity primary key,
	category_id bigint references categories(id),
	first_name varchar(50) not null,
	last_name varchar(50) not null,
	address text not null,
	phone_num varchar(13) not null,
	email text ,
	image_path text,
	work_experience int,
	region text ,
	district text,
	start_work_time text,
	end_work_time text,
	lunch_time text,
	password_hash text not null,
	salt text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now(),
	is_male bool default false,
	fees real not null
	
);

create table hospitals
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	image_path text not null,
	desctiption text ,
	phone_num1 varchar(13) not null,
	phone_num2 varchar(13),
	address text ,
	region text ,
	district text,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table hospital_doctor
(
	id bigint generated always as identity primary key,
	hospital_id bigint references hospitals(id) not null,
	doctor_id bigint references doctors (id) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);



create table users 
(
	id bigint generated always as identity primary key,
	first_name varchar(50) ,
	last_name varchar(50),
	phone_num varchar(13),
	image_path text ,
	password_hash text not null,
	salt text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now(),
	is_male bool default false,
	email text,
	identity_role text
);

create table bookings
(
	id bigint generated always as identity primary key,
	user_id bigint references users(id) not null,
	doctor_id bigint references doctors(id) not null,
	start_time  text,
	end_time text,
	booking_date text,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table raitings
(
	id bigint generated always as identity primary key,
	doctor_id bigint references doctors(id) not null,
	user_id bigint references users(id) not null,
	star_count float ,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);


