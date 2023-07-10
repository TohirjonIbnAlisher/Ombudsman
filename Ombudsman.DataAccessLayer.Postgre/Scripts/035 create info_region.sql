CREATE TABLE ombudsman.info_region
(
    id integer NOT NULL,
    code character varying(3) NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(250) NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT info_region_pkey PRIMARY KEY (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)