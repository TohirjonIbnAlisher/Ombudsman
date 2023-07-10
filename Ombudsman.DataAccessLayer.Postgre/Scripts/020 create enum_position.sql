CREATE TABLE ombudsman.enum_position
(
    id integer NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(250) NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT position_pkey PRIMARY KEY (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)