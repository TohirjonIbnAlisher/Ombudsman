CREATE TABLE ombudsman.info_organization
(
    id integer NOT NULL ,
    code character varying(10) NOT NULL,
    stir character varying(20) NOT NULL,
    name character varying(500) NOT NULL,
    organization_type_id integer NOT NULL,
    organization_id integer,
    region_id integer NOT NULL,
    district_id integer NOT NULL,
    organization_level_id integer NOT NULL,
    address character varying(500) NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT info_organization_pkey PRIMARY KEY (id),
    CONSTRAINT fk_district FOREIGN KEY (district_id)
        REFERENCES ombudsman.info_district (id) ,
    CONSTRAINT fk_organization FOREIGN KEY (organization_id)
        REFERENCES ombudsman.info_organization (id) ,
    CONSTRAINT fk_organization_level FOREIGN KEY (organization_level_id)
        REFERENCES ombudsman.enum_organization_level (id),
    CONSTRAINT fk_organization_type FOREIGN KEY (organization_type_id)
        REFERENCES ombudsman.enum_organization_type (id),
    CONSTRAINT fk_region FOREIGN KEY (region_id)
        REFERENCES ombudsman.info_region (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)