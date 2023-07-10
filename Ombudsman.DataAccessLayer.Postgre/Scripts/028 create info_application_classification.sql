CREATE TABLE ombudsman.info_application_classification
(
    id integer NOT NULL ,
    grouper boolean NOT NULL,
    code character varying(15)  NOT NULL,
    full_name character varying(500)  NOT NULL,
    short_name character varying(250) NOT NULL,
    state_id integer NOT NULL,
    organization_id integer NOT NULL,
    application_classification_id integer,
    organization_level_id integer NOT NULL,
    CONSTRAINT info_application_classification_pkey PRIMARY KEY (id),
    CONSTRAINT fk_application_classification FOREIGN KEY (application_classification_id)
        REFERENCES ombudsman.info_application_classification (id),
    CONSTRAINT fk_organization FOREIGN KEY (organization_id)
        REFERENCES ombudsman.info_organization ,
    CONSTRAINT fk_organization_level FOREIGN KEY (organization_level_id)
        REFERENCES ombudsman.enum_organization_level (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)
