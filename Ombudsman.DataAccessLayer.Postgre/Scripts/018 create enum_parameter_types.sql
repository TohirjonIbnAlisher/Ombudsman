CREATE TABLE ombudsman.enum_parameter_types
(
    id integer NOT NULL,
    code character varying(5) NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(250) NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT parameter_types_pkey PRIMARY KEY (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)