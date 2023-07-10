CREATE TABLE ombudsman.info_mfy
(
    id integer NOT NULL,
    code character varying(10) NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(250) NOT NULL,
    region_id integer NOT NULL,
    district_id integer NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT info_mfy_pkey PRIMARY KEY (id),
    CONSTRAINT fk_district FOREIGN KEY (district_id)
        REFERENCES ombudsman.info_district (id) ,
    CONSTRAINT fk_region FOREIGN KEY (region_id)
        REFERENCES ombudsman.info_region (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)