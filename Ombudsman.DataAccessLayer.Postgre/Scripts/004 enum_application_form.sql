CREATE TABLE ombudsman.enum_application_form
(
    id integer NOT NULL,
    full_name character varying(500) NOT NULL,
    short_name character varying(500) NOT NULL,
    state_id integer NOT NULL,
    CONSTRAINT application_form_pkey PRIMARY KEY (id),
    CONSTRAINT fk_state FOREIGN KEY (state_id)
        REFERENCES ombudsman.enum_state (id)
)