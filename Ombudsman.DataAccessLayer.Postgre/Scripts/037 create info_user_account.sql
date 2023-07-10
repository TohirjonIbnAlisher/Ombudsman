CREATE TABLE ombudsman.info_user_account
(
    id integer,
    fio character varying(50) NOT NULL,
    email character varying(25) NOT NULL,
    login character varying(25) NOT NULL,
    password character varying(50) NOT NULL,
    state_id integer NOT NULL,
    organization_id integer NOT NULL,
    position_id integer NOT NULL,
    role_id integer NOT NULL,
    salt character varying NOT NULL,
    refresh_token_expire_date date,
    refresh_token character varying(250),
    CONSTRAINT user_account_pkey PRIMARY KEY (id),
    CONSTRAINT fk_organization FOREIGN KEY (organization_id)
        REFERENCES ombudsman.info_organization (id) ,
    CONSTRAINT fk_position FOREIGN KEY (position_id)
        REFERENCES ombudsman.enum_position (id),
    CONSTRAINT fk_role FOREIGN KEY (role_id)
        REFERENCES ombudsman.enum_role (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)